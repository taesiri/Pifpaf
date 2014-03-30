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

            Input.gyro.enabled = true;
        }


        private void Update()
        {
            transform.position += Vector3.up*VerticalSpeed*Time.deltaTime;
            PasheCam.position += Vector3.up*VerticalSpeed*Time.deltaTime;

            HandleInputs();
        }

        private void HandleInputs()
        {
            var xO = Input.GetAxis("Horizontal");

            transform.position += Vector3.right*xO*HorizontalSpeed*Time.deltaTime;


#if UNITY_IPHONE || UNITY_ANDROID
            //Boundary checks required 
            transform.position += Vector3.right*Time.deltaTime*GyroSpeed*GyroSign(Input.gyro.attitude.x);
#endif
        }


        public void OnGUI()
        {
            Vector2 ratio = Location.GuiOffset;
            Matrix4x4 guiMatrix = Matrix4x4.identity;
            guiMatrix.SetTRS(new Vector3(1, 1, 1), Quaternion.identity, new Vector3(ratio.x, ratio.y, 1));
            GUI.matrix = guiMatrix;

         

            GUI.matrix = Matrix4x4.identity;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
        }


        private int GyroSign(float value)
        {
            if (Mathf.Abs(value) < 0.01f) return 0;
            if (value > 0) return 1;
            if (value < 0) return -1;

            return 0;
        }
    }
}