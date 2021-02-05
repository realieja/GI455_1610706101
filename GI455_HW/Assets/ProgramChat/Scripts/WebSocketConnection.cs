using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Random = UnityEngine.Random;


namespace ProgramChat
{
    public class WebSocketConnection : MonoBehaviour
    {
        private WebSocket webSocket,OnReceive;
        public InputField IpAddressField;
        public InputField PortField;
        public GameObject ConnectPanel;

        public InputField MessageField;
        public GameObject ChatPanel,TextObj,ChatBox,TextBackObj;
        void Start()
        {
           // webSocket=new WebSocket("ws://127.0.0.1:4243");

           
            //webSocket.OnMessage += OnMessage;
            
            //webSocket.Connect();
            //webSocket.Send("y eiei");
            
        }

        // Update is called once per frame
        void Update()
        {
           
            /*if (Input.GetKeyDown(KeyCode.Return))
            {
                if (webSocket.ReadyState == WebSocketState.Open)
                {
                    webSocket.Send(Message.text);
                    //webSocket.Send("Random Number " + Random.Range(0, 1000));
                }
            }*/
        }

        public void ConnectServer()
        {
            if (IpAddressField.text == "127.0.0.1" && PortField.text == "4243")
            {
                webSocket=new WebSocket("ws://127.0.0.1:4243");
                webSocket.OnMessage += OnMessage;
                webSocket.Connect();
                ConnectPanel.SetActive(false);
                ChatPanel.SetActive(true);
            }
        }

        public void SendMessageToChat()
        {
            if (MessageField.text != "")
            {
                SendNewMessage(MessageField.text);
                MessageField.text = "";
            }
        }
        
        public void SendNewMessage(string text)
        {
            if (webSocket.ReadyState == WebSocketState.Open)
            {
                webSocket.Send(MessageField.text);
                
                Message newMessage = new Message();
                newMessage.text = text;
                GameObject newText = Instantiate(TextObj, ChatBox.transform);
                newMessage.textObj = newText.GetComponent<Text>();
                newMessage.textObj.text = newMessage.text;
            }
        }
        [System.Serializable]
        public class Message
        {
            public string text;
            public Text textObj;
            public Text textBackObj;
        }

        private void OnDestroy()
        {
            if (webSocket != null)
            {
                webSocket.Close();
            }
        }

        public void OnMessage(object sender,MessageEventArgs messageEventArgs)
        {
            
                Debug.Log("Receive msg : " + messageEventArgs.Data);
                Message newMessageBack = new Message();
                newMessageBack.text = messageEventArgs.Data;
                GameObject newTextBack = Instantiate(TextBackObj, ChatBox.transform);
                newMessageBack.textBackObj = newTextBack.GetComponent<Text>();
                newMessageBack.textBackObj.text = newMessageBack.text;
            
        }
    }
}

