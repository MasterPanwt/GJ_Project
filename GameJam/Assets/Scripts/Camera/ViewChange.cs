using UnityEngine;

public class CameraToggleByE : MonoBehaviour
{
    [Header("两个锚点")]
    public Transform pointA;
    public Transform pointB;

    [Header("相机（留空自动取 Camera.main）")]
    public Camera cam;

    [Header("切换")]
    public KeyCode key = KeyCode.E;
    [Tooltip("0 = 瞬移；大于 0 = 过渡时长（秒）")]
    public float blendTime = 0.35f;
    public AnimationCurve ease = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    public bool followAnchor = false;

    [Header("透视相机 FOV")]
    public bool animateFov = true;
    [Range(1f, 179f)] public float fovA = 60f;
    [Range(1f, 179f)] public float fovB = 35f;

    [Header("正交相机 Size（正交模式下 FOV 无效）")]
    public bool animateOrthoSize = false;
    public float orthoSizeA = 5f;
    public float orthoSizeB = 3f;

    Transform current;
    bool blending;
    float t;
    Vector3 fromPos;
    Quaternion fromRot;
    float fromFov;
    float fromSize;

    void Awake()
    {
        if (!cam) cam = Camera.main;
    }

    void Start()
    {
        if (!cam || !pointA) return;

        current = pointA;
        SnapTo(current);
    }

    void Update()
    {
        if (Input.GetKeyDown(key)) Toggle();
        if (!cam) return;

        if (blending)
        {
            t += Time.deltaTime / Mathf.Max(0.0001f, blendTime);

            float k = ease.Evaluate(Mathf.Clamp01(t));
            Apply(k);

            if (t >= 1f) blending = false;
        }
        else if (followAnchor && current)
        {
            cam.transform.SetPositionAndRotation(current.position, current.rotation);
        }
    }

    public void Toggle()
    {
        if (!cam || !pointA || !pointB) return;

        current = (current == pointA) ? pointB : pointA;

        if (blendTime <= 0f)
        {
            SnapTo(current);
            blending = false;
            return;
        }

        fromPos = cam.transform.position;
        fromRot = cam.transform.rotation;
        fromFov = cam.fieldOfView;
        fromSize = cam.orthographicSize;
        t = 0f;
        blending = true;
    }

    void Apply(float k)
    {
        cam.transform.SetPositionAndRotation(
            Vector3.LerpUnclamped(fromPos, current.position, k),
            Quaternion.SlerpUnclamped(fromRot, current.rotation, k));

        if (!cam.orthographic)
        {
            if (!animateFov) return;

            float targetFov = (current == pointA) ? fovA : fovB;

            cam.fieldOfView = Mathf.Clamp(
                Mathf.LerpUnclamped(fromFov, targetFov, k), 1f, 179f);
        }
        else if (animateOrthoSize)
        {
            float targetSize = (current == pointA) ? orthoSizeA : orthoSizeB;

            cam.orthographicSize = Mathf.Max(0.01f,
                Mathf.LerpUnclamped(fromSize, targetSize, k));
        }
    }

    void SnapTo(Transform anchor)
    {
        cam.transform.SetPositionAndRotation(anchor.position, anchor.rotation);

        if (!cam.orthographic && animateFov)
            cam.fieldOfView = (anchor == pointA) ? fovA : fovB;

        if (cam.orthographic && animateOrthoSize)
            cam.orthographicSize = (anchor == pointA) ? orthoSizeA : orthoSizeB;
    }
}