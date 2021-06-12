# BlueBack.Excel
Excel操作
* スプレッドシートからの読み込み
* バイナリからの読み込み
* JsonItemへのコンバート

## ライセンス
MIT License
* https://github.com/bluebackblue/Excel/blob/main/LICENSE

## 外部依存 / 使用ライセンス等
* https://github.com/bluebackblue/JsonItem
### サンプルのみ
* https://github.com/bluebackblue/AssetLib

## 動作確認
Unity 2020.2.0b14

## UPM
### 最新
* https://github.com/bluebackblue/Excel.git?path=unity_Excel/Assets/UPM#0.0.10
### 開発
* https://github.com/bluebackblue/Excel.git?path=unity_Excel/Assets/UPM

## Unityへの追加方法
* Unity起動
* メニュー選択：「Window->Package Manager」
* ボタン選択：「左上の＋ボタン」
* リスト選択：「Add package from git URL...」
* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」
### 注
Gitクライアントがインストールされている必要がある。
* https://docs.unity3d.com/ja/current/Manual/upm-git.html
* https://git-scm.com/

## 例
* ```[root]```の右セルはシート名。
* ```[param_type]```の右セルは型を列挙。```string``` ```int``` ```float```が指定可能。```-```始まりはコメント扱いで無視。
* ```[param_name]```の右セルは名前を列挙。```[param_type]```と対
* ```*```のある行がコンバート対象。
* 終端には```[end]```が必要。
* 左上に```[end]```があるシートはスキップ
![Sample01](/sample00.png)
```
{
	"sheetname" : [
		{
			"namae" : "satou",
			"nedan" : 10,
			"val" : 1.3
		},
		{
			"namae" : "sio",
			"nedan" : 20,
			"val" : 1.4
		},
		{
			"namae" : "shoyu",
			"nedan" : 30,
			"val" : 1.5
		}
	]
}
```

