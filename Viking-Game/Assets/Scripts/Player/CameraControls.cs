using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform target;
    public float distance = 3.5f; // الاتجاه الي نريده
    private float currentDistance; // المسافة الحالية
    [Range(1, 10)] public float xSpeed = 2; 
    [Range(1, 10)] public float ySpeed = 2; 

    private float yMin = -70f;
    private float yMax = 80f;

    public float distanceMin = 1; //اقل مسافة بالنسبة للمسار
    public float distanceMax = 10; // اقصى مسافة بالنسبة للمسار

    public Vector3 offset; // نغير المسار 

    private float x; // دوران بشكل افقي
    private float y; // دوران بشكل عامودي

    public LayerMask clipMask; // نشيل عوائق الكاميرا بحيث ماتخترق الجدران والارض

   
    void Start()
    {
        currentDistance = distance; // نحط المسافة الحالية للمسافة المطلوبة
        Vector3 angles = transform.eulerAngles; 
        x = angles.y; // نخزن اكس بالمسار الافقي
        y = angles.x; // نخزن الواي بالمسار العامودي
    }

    void LateUpdate()
    {
        if (target) // كل الي تحت يشتغل في حال فقط عندنا مسار الي هو اللاعب
        {
            x += Input.GetAxis("Mouse X") * xSpeed; // نحط دوران الاكس للماوس اكس و نضربها بالسرعة 
            y -= Input.GetAxis("Mouse Y") * ySpeed; // نحط دوران الواي للماوس واي ونضربها بالسرعة 
            y = Mathf.Clamp(y, yMin, yMax); // نحط حد بين فوق وتحت عشان مايسوي باك فليب بالكاميرا

            Quaternion rotation = Quaternion.Euler(y, x, 0); // نخزن الدوران للاستعمال الاسرع

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            //هذه الفقرة مختصة بانه نشوف ايش الاشياء الي ممكن الكاميرا تخترقها ونحد منها
            Vector3 direction = target.position + offset - transform.position;
            RaycastHit hit;
            if (Physics.SphereCast(target.position + offset, 0.25f, -direction / direction.magnitude, out hit, currentDistance + 0.125f, clipMask))
                currentDistance = Mathf.Clamp(hit.distance, 0, distance);
            else if (currentDistance != distance)
                currentDistance = Mathf.Lerp(currentDistance, distance, 10 * Time.deltaTime);
            
            //نحط الموضع مع الاخذ بعين الاعتبار الدوران
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -currentDistance) + (target.position + offset);

            // ونعدل على الدوران والموضع بعد ما اهتمينا بالدوران
            transform.rotation = rotation;
            transform.position = position;

            // ننادي الطريقة الي عملناها بسكربت اللاعب الي نتحكم فيها بدوران اللاعب
            target.GetComponent<PlayerControls>().SetRotation(x); 
        }
    }

    // تسمح لنا باختيار المسار الي نريده عشان الكاميرا تلحقه
    public void SetTarget(Transform t)
    {
        target = t; 
        offset.y = target.GetComponent<CharacterController>().height - 0.25f; //نحط علو الكاميرا استناداً الى علو اللاعب او المسار المختار
    }
}