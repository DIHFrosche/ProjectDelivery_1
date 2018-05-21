using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catshoot : MonoBehaviour {

    public float maxForce;
    float heightPress;
    public float maxHeight = 10;
    public float minHeight = 1;

    public Rigidbody cat;
    [Header("Mer Gravity för hårdare slag")]
    public float gravity = -18;

    public bool debugPath;
    public Transform target;

    Vector3 directionBetweenCatAndTarget;
    float currentHeight;
    float targetMoveSpeed = 0.9f;

    [SerializeField] GameObject catBatPivot;
    float currentPivotRotation;

    [SerializeField]GameObject linePrefab;

    GameObject[] lines = new GameObject[30];

    private void Start() {
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = Instantiate(linePrefab);
        }
    }

    void Update () {


        print(FindObjectOfType<SelectCat>().cat);
        if(FindObjectOfType<SelectCat>().cat != null) {
            cat = FindObjectOfType<SelectCat>().cat.GetComponent<Rigidbody>();
            Vector3 targetPos = Vector3.Scale(target.transform.position, new Vector3(1, 0, 1));
            Vector3 catPos = Vector3.Scale(cat.transform.position, new Vector3(1, 0, 1));
            directionBetweenCatAndTarget = (targetPos - catPos).normalized;
            Debug.DrawRay(cat.transform.position, directionBetweenCatAndTarget * 1000, Color.red);
            if (Input.GetKey(KeyCode.RightArrow)){
                currentHeight += 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                currentHeight -= 1;
            }
            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

            if (Input.GetKey(KeyCode.UpArrow)) {
                currentPivotRotation--;
                currentPivotRotation = Mathf.Clamp(currentPivotRotation, -90, 0);
                catBatPivot.transform.eulerAngles = new Vector3(0, 0, currentPivotRotation);
                target.position += directionBetweenCatAndTarget * targetMoveSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                currentPivotRotation++;
                currentPivotRotation = Mathf.Clamp(currentPivotRotation, -90, 0);
                catBatPivot.transform.eulerAngles = new Vector3(0, 0, currentPivotRotation);
                target.position -= directionBetweenCatAndTarget * targetMoveSpeed;
            }
            if (Input.GetKey(KeyCode.Mouse0)) {
                Launch();
                StartCoroutine(slamBat());
                GetComponent<SelectCat>().cat = null;
                GetComponent<CatBat>().club.SetActive(false);
            }
            if (debugPath == true) {
                DrawPath();
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(target.position, 1f);
    }
    void Launch() {
        Physics.gravity = Vector3.up * gravity;
        cat.useGravity = true;
        cat.velocity = CalculateLaunchData().initialVelocity;
    }

    LaunchData CalculateLaunchData() {
        float displacementY = target.position.y - cat.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - cat.position.x, 0, target.position.z - cat.position.z);

        float time = Mathf.Sqrt(-2 * currentHeight / gravity) + Mathf.Sqrt(2 * (displacementY - currentHeight) / gravity);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * currentHeight);

        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    void DrawPath() {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawPoint = cat.position;

        int resolution = 30;
        for (int i = 0; i <= resolution; i++) {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = cat.position + displacement;
            lines[i].GetComponent<LineRenderer>().SetPosition(0, previousDrawPoint);
            lines[i].GetComponent<LineRenderer>().SetPosition(1, drawPoint);
            //Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }

    struct LaunchData {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget) {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }

    }

    IEnumerator slamBat() {
        int divider = 1;
        float amountOfShift =  currentPivotRotation/divider;
        for (int i = 0; i < 1; i++) {
            currentPivotRotation -= amountOfShift-10;
            catBatPivot.transform.eulerAngles = new Vector3(0, 0, currentPivotRotation);
            yield return null;
        }

    }
}