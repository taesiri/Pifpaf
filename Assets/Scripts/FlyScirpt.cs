using UnityEngine;

namespace Assets.Scripts
{
    public class FlyScirpt : MonoBehaviour
    {
        public float VerticalSpeed = 1.0f;
        public float HorizontalSpeed = 10.0f;
        public float GyroSpeed = 2.0f;
        public float MovementSpeed = 2.0f;
        public Transform PasheCam;
        public GUISkin MenuSkin;
        public GUILocationHelper Location = new GUILocationHelper();
        public GameManager Gmanger;

        private int _lastSign;

        private Matrix4x4 _guiMatrix = Matrix4x4.identity;

        private void Start()
        {
            if (!PasheCam)
            {
                Debug.LogError("Pashe Cam not found");
            }
            if (!Gmanger)
            {
                Debug.LogError("Game manager not found");
            }

            Location.PointLocation = GUILocationHelper.Point.Center;
            Location.UpdateLocation();


            Vector2 ratio = Location.GuiOffset;
            _guiMatrix.SetTRS(new Vector3(1, 1, 1), Quaternion.identity, new Vector3(ratio.x, ratio.y, 1));
        }


        private void Update()
        {
            transform.position += Vector3.up*VerticalSpeed*Time.deltaTime;
            PasheCam.position += Vector3.up*VerticalSpeed*Time.deltaTime;

            HandleInputs();
        }

        private void HandleInputs()
        {
#if UNITY_IPHONE || UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                var sign = (Input.touches[0].position.x < Location.CenterOfScreen.x) ? -1 : 1;

                if (sign == 1)
                {
                    if (transform.position.x < 2.7f)
                    {
                        transform.position += Vector3.right*Time.deltaTime*MovementSpeed;
                    }
                }
                else if (sign == -1)
                {
                    if (transform.position.x > -2.5f)
                    {
                        transform.position += Vector3.left*Time.deltaTime*MovementSpeed;
                    }
                }
            }
#else

#endif
        }

        private void HandleInputGyroscope()
        {
#if UNITY_IPHONE || UNITY_ANDROID
            //Boundary checks required  --2.6 2.4


            _lastSign = GyroSign(Input.gyro.attitude.x + Input.gyro.attitude.y);
            transform.position += Vector3.right*Time.deltaTime*GyroSpeed*_lastSign;


#else
            var xO = Input.GetAxis("Horizontal");
            transform.position += Vector3.right*xO*HorizontalSpeed*Time.deltaTime;
#endif
        }

        public void OnGUI()
        {
            GUI.matrix = _guiMatrix;

            GUI.Label(new Rect(10, 10, 500, 30), string.Format("{0}:{1}", Screen.width, Screen.height));

            if (Input.touchCount > 0)
            {
                GUI.Label(new Rect(10, 60, 500, 30), string.Format("{0}", Input.touches[0].position));
            }

            GUI.matrix = Matrix4x4.identity;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log(other.gameObject.name + "STAY");
        }

        private int GyroSign(float value)
        {
            if (Mathf.Abs(value) < 0.05f) return 0;
            if (value > 0) return 1;
            if (value < 0) return -1;

            return 0;
        }
    }
}