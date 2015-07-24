# uNetSendMessage
uNetをつかってServerからClientに対してGameObject名とMethodを指定し、SendMessageのようにつかう。  
ServerからClientのみ命令可能。
リアルタイムに同期する目的ではなく任意のタイミングのみ、処理を実行したい時に使用。

unity3d 5.1.1p2

## 使い方

通常uNetを使うようなにNetworkManagerを設定。

GameObjectにNetworkIdentityをつけ、UnetActionをつける。

あとは、UnetActionの  
SendNetMessage(string sendGameObjectName, string methodName);  
SendNetMessageWithString(string sendGameObjectName, string methodName, string str);  
などをつかう。

sendGameObjectName: 下記で指定するmethodNameを有するGameObject名。  
methodName: 実行する関数。

##サンプル

uNetSendMessage.unity 

Clientのオブジェクトの回転や色変更など。
