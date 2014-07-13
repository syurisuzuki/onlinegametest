﻿using UnityEngine;

public class NetworkManager : Photon.MonoBehaviour {
		void Awake () {
				//マスターサーバーへ接続
				PhotonNetwork.ConnectUsingSettings("v0.1");
		}

		void Update () {
		}

		//ロビー参加成功時のコールバック
		void OnJoinedLobby() {
				//ランダムにルームへ参加
				PhotonNetwork.JoinRandomRoom();
		}

		//ルーム参加失敗時のコールバック
		void OnPhotonRandomJoinFailed() {
				Debug.Log("ルームへの参加に失敗しました");
				//名前のないルームを作成
				PhotonNetwork.CreateRoom(null);
		}

		//ルーム参加成功時のコールバック
		void OnJoinedRoom() {
				Debug.Log("ルームへの参加に成功しました");
				//プレイヤーをインスタンス化
				Vector3 spawnPosition = new Vector3(0,2,0); //生成位置
				PhotonNetwork.Instantiate("PlayerPrefab", spawnPosition, Quaternion.identity, 0);
		}

		void OnGUI() {
				//サーバーとの接続状態をGUIへ表示
				GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
				if (GUI.Button (new Rect (200, 550, 40, 40), "Click")) {
						Vector3 spawnPosition = new Vector3 (0, 2, 0); //生成位置
						PhotonNetwork.Instantiate ("PlayerPrefab", spawnPosition, Quaternion.identity, 0);
				}
		}
}