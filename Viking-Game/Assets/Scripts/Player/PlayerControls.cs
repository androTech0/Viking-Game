using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private Vector3 moveDirection;  // عشان نتحكم بالاتجاهات
    private Animator anim; // عشان نتحكم بالانيميشن
    private CharacterController controller; // نتحكم بتحرك اللاعب بواسطة ال كاراكتركونترول
    private CameraControls cam; // نتحكم بالكاميرا

    public float jump = 10;  // قفز 
    public float gravity = 20;   // الجاذبية

    private bool onGround = true; // نتأكد اذا كنا بالارض
    private float ConstantForce = -10;  // نسحب 10 عشان لا نطير


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraControls>();
    }

    void Update()
    {
        onGround = controller.isGrounded; // نحط الشرط الي يتأكد انه اللاعب عالارض
        if (anim.GetBool("Ground") != onGround) // اذا انميتر الارض ماكان نفسه
        {
            anim.SetBool("Ground", onGround);
            if (onGround)
            {
                ConstantForce = -10; // طالما نحن بالارض نحط قوة الجاذبية على ناقص 10
                anim.SetBool("Land", true); // ونشغل انميشن الي يسمحلنا نهبط
            }
            else if (ConstantForce == -10) ConstantForce = 0; //اذا ما قفزنا وماكنا عالارض, فـ لازم نشيل القوة الجاذبية بحكم انه نحن مو عالارض
        }

        if (onGround) // اذا كنا عالارض
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Jump", true); 
                ConstantForce = jump; // حط الجاذبية الحالية الى جاذبية القفز
            }
        }
        else ConstantForce -= gravity * Time.deltaTime; // اذا كنا بالهوا نحط جاذبية مع كل فريم

        // نخزن المشي بفكتور 3 اسمه موف دايركشن عشان نمشي بالكيبورد
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //نحط الانميتر حقنا على نفس حركات المشي
        anim.SetFloat("Horizontal", moveDirection.x, 0.1f, (2.5f - moveDirection.magnitude) * Time.deltaTime);
        anim.SetFloat("Vertical", moveDirection.z, 0.1f, (2.5f - moveDirection.magnitude) * Time.deltaTime);
        
        Vector3 translate = moveDirection.normalized * 5; // نسوي نورملايز عشان اللاعب ما يأسرع لما نمشي بشكل يمين قطري يعني يمين مائل او يسار مائل والخ 
        if (translate.z < 0) translate *= 0.75f; // اذا رجعنا لورا خلي اللاعب يرجع بشكل بطيئ
        translate.y = ConstantForce; // نحط المشي حقنا بالفيكتور الواي على الجاذبية الحالية
        controller.Move(transform.rotation * translate * Time.deltaTime); // الامر الي يعطي الكونترول عشان يمشي
    }
    

    // طريقة تسمح لنا ننادي دوران اللاعب من خلال سكربت الموجود عالكاميرا نفسه
    public void SetRotation(float rot)
    {
        if (moveDirection.magnitude > 0)  // اذا كنا نتحرك اي خطوة كانت , يمين يسار امام خلف , الخ
            transform.rotation = Quaternion.Euler(0, rot, 0); //اذا نتحرك , نحط تحركات اللاعب حسب دوران الكاميرا 
    }

   
}
