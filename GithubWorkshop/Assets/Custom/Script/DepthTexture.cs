using UnityEngine;

public class DepthTexture : MonoBehaviour
{
    private static readonly int PROPERTY_COLOR = Shader.PropertyToID("_Color");
    private static readonly int PROPERTY_START = Shader.PropertyToID("_Start");
    private static readonly int PROPERTY_END = Shader.PropertyToID("_End");

    private static readonly int PROPERTY_TARGET_DISTANCE = Shader.PropertyToID("_TargetDistance");
    private static readonly int PROPERTY_TARGET_THICKNESS = Shader.PropertyToID("_TargetThickness");
    private static readonly int PROPERTY_NEAR_MAX = Shader.PropertyToID("_NearMax");
    private static readonly int PROPERTY_FAR_MIN = Shader.PropertyToID("_FarMin");

    [SerializeField]
    private Shader _shader;
    private Material _material;

    [SerializeField]
    private Color _color = Color.white;
    [SerializeField]
    private float _start = 0f;
    [SerializeField]
    private float _end = 20f;

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _targetThickness = 0.1f;

    [SerializeField, Range(0f, 1f)]
    private float _nearMaxDepth = 0.2f;
    [SerializeField, Range(0f, 1f)]
    private float _farMinDepth = 0.6f;



    void Start()
    {
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;

        _material = new Material(_shader);
        OnValidate();
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, _target.position);
        _material.SetFloat(PROPERTY_TARGET_DISTANCE, distance);
    }

    private void OnValidate()
    {
        if (_material == null)
        {
            return;
        }
        _material.SetColor(PROPERTY_COLOR, _color);
        _material.SetFloat(PROPERTY_START, _start);
        _material.SetFloat(PROPERTY_END, _end);
        _material.SetFloat(PROPERTY_START, _start);
        _material.SetFloat(PROPERTY_TARGET_THICKNESS, _targetThickness);
        _material.SetFloat(PROPERTY_NEAR_MAX, _nearMaxDepth);
        _material.SetFloat(PROPERTY_FAR_MIN, _farMinDepth);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture dest)
    {
        Graphics.Blit(source, dest, _material);
    }
}
