using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_CameraMove : MonoBehaviour {
    //Abandoned !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    private Vector3 quat;
    //public Transform _XForm_Parent;
    private Vector3 thisQuat;
    protected Vector3 _LocalRotation;
    [SerializeField] protected float _CameraDistance = 50f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled = false;
    private float fixedAngle;

    private float fixedValue;
    // Use this for initialization
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
        quat = this.transform.parent.eulerAngles;
        thisQuat = this.transform.eulerAngles;
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisabled = !CameraDisabled;

        if (Input.GetMouseButton(1))
        {
            CameraDisabled = false;
        }
        else
        {
            CameraDisabled = true;
        }
        if (!CameraDisabled)
        {
            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _LocalRotation.y += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.x += Input.GetAxis("Mouse Y") * MouseSensitivity;

                //Clamp the y Rotation to horizon and not flipping over at the top
                
                if (_LocalRotation.x > 0f)
                    _LocalRotation.x = 0f;
                else if (_LocalRotation.x < -60f)
                    _LocalRotation.x = -60f;
                    
                /*
                if (_LocalRotation.y < 0f)
                    _LocalRotation.y = 0f;
                else if (_LocalRotation.y > 90f)
                    _LocalRotation.y = 90f;
                    */
            }
            //Zooming Input from our Mouse Scroll Wheel

        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            //Debug.Log("Rolling");
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

            ScrollAmount *= (this._CameraDistance * 0.3f);

            this._CameraDistance += ScrollAmount * -1f;

            this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 10f);
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.x, 0, 0);
        //Quaternion QT = Quaternion.Euler(_LocalRotation.y , _LocalRotation.x, thisQuat.z);
        //Quaternion QT = Quaternion.Euler(quat.x, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        //transform.position = new Vector3(transform.position.x, transform.position.y+_LocalRotation.x/7.5f,transform.position.z);
        if (Mathf.Ceil(this.transform.parent.eulerAngles.x) == 0)
        {
            fixedValue = 360f;
        }
        else
        {
            fixedValue = this.transform.parent.eulerAngles.x;
        }
        fixedAngle =(Mathf.Clamp(fixedValue,300,360) - 360) / 4.5f;
    
        this._XForm_Parent.position = new Vector3(0f, fixedAngle, 0);
        //float fixAng = (this.transform.parent.eulerAngles.x - 360f);
        if (this._XForm_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            Debug.Log("In Process!!!!!");
            //Debug.Log("Angle"+ this.transform.parent.eulerAngles.x);
           
            
            //Debug.Log("Angle" + fixedAngle);
            //Debug.Log("FixAngle" + fixAng);
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
            /*
            if (fixedAngle == 0)
            {
                Debug.Log("Angle==0");
                this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
            }
            else
            {
                Debug.Log("Angle>0");
                this._XForm_Camera.localPosition = new Vector3(0f, Mathf.Lerp(this._XForm_Camera.localPosition.y, fixedAngle * -1f, Time.deltaTime * ScrollDampening), Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
            }
            */
            
        }
        else
        {
            
            //Debug.Log("In Process!!!!!");
            //this.transform.position = new Vector3(transform.position.x, transform.position.y + _LocalRotation.x / 7.5f, transform.position.z);
        }
        
    }
}
