using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

namespace CitiesSkylinesTestMod
{

    public class JsonData
    {
        public int number;
    }

    public class CustomObject : MonoBehaviour
    {
        public bool isSending;
        public int number;

        public CustomObject()
        {
            isSending = false;
            number = 0;
        }

        public void setNumber(int _number)
        {
            number = _number;
        }

        public void Start()
        {
        }

        private IEnumerator uploadToCityIO()
        {

            // we need to hand roll a http request...
            var url = "https://cityio.media.mit.edu/api/table/citiesskylines/";
            var req = new UnityWebRequest(url, "POST");

            var data = new JsonData();
            data.number = number;
            var json = JsonUtility.ToJson(data);
            var bytes = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = (UploadHandler)new UploadHandlerRaw(bytes);
            req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.Send();

            // we want to behave
            yield return new WaitForSeconds(5);
            isSending = false;
        }

        public void Update()
        {
            if (!isSending)
            {
                isSending = true;
                StartCoroutine(uploadToCityIO());
            }
        }

    }
}
