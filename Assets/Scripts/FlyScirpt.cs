using UnityEngine;

namespace Assets.Scripts
{
    public class FlyScirpt : MonoBehaviour
    {
        public float VerticalSpeed = 1.0f;
        public float HorizontalSpeed = 10.0f;
        public float GyroSpeed = 2.0f;
        public Transform PasheCam;
        public GUISkin MenuSkin;
        public GUILocationHelper Location = new GUILocationHelper();
        public GameManager Gmanger;

        private int _lastSign = 0;

        private void Start()
        {
            Debug.Log(Screen.width);
            Debug.Log(Screen.height);
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

            Input.gyro.enabled = true;
        }


        private void Update()
        {
            transform.position += Vector3.up*VerticalSpeed*Time.deltaTime;
            PasheCam.position += Vector3.up * VerticalSpeed * Time.deltaTime;

            HandleInputs();
        }

        private void HandleInputs()
        {
#if UNITY_IPHONE || UNITY_ANDROID
            //Boundary checks required 
            _lastSign = GyroSign(Input.gyro.attitude.x + Input.gyro.attitude.y);
            transform.position += Vector3.right*Time.deltaTime*GyroSpeed*_lastSign;
#else
            var xO = Input.GetAxis("Horizontal");
            transform.position += Vector3.right*xO*HorizontalSpeed*Time.deltaTime;
#endif
        }

        public void OnGUI()
        {
            Vector2 ratio = Location.GuiOffset;
            Matrix4x4 guiMatrix = Matrix4x4.identity;
            guiMatrix.SetTRS(new Vector3(1, 1, 1), Quaternion.identity, new Vector3(ratio.x, ratio.y, 1));
            GUI.matrix = guiMatrix;

            GUI.Label(new Rect(10, 10, 500, 30), string.Format("{0}", Input.gyro.attitude));
            GUI.Label(new Rect(10, 60, 500, 30), string.Format("{0}", Input.gyro.gravity));
            GUI.Label(new Rect(10, 110, 500, 30), string.Format("{0}", Input.gyro.rotationRate));
            GUI.Label(new Rect(10, 160, 500, 30), string.Format("{0}", Input.gyro.rotationRateUnbiased));
            GUI.Label(new Rect(10, 210, 500, 30), string.Format("{0}", Input.gyro.updateInterval));
            GUI.Label(new Rect(10, 260, 500, 30), string.Format("{0}", Input.gyro.userAcceleration));
            GUI.Label(new Rect(10, 310, 500, 30), string.Format("{0}", _lastSign));

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