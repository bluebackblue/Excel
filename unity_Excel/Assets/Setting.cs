

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief �ݒ�B
*/


/** Setting
*/
public class Setting
{
	/** AUTHOR_NAME
	*/
	public const string AUTHOR_NAME = "BlueBack";

	/** PACKAGE_NAME
	*/
	public const string PACKAGE_NAME = "Excel";

	/** PACKAGEJSON
	*/
	public const string PACKAGEJSON_UNITY = "2020.1";

	/** PACKAGEJSON
	*/
	public const string PACKAGEJSON_DISCRIPTION = "Excel����";

	/** PACKAGEJSON
	*/
	public static readonly string[] PACKAGEJSON_KEYWORD = new string[]{
		"excel"
	};

	/** GetPackageVersion
	*/
	public static string GetPackageVersion()
	{
		return BlueBack.Excel.Version.packageversion;
	}

	/** ReadmeMd_StringCreator_Argument
	*/
	public struct ReadmeMd_StringCreator_Argument
	{
		public string version;
	}

	/** ReadmeMd_StringCreator_Type
	*/
	public delegate string[] ReadmeMd_StringCreator_Type(in ReadmeMd_StringCreator_Argument a_argument);

	/** READMEMD_STRINGCREATOR
	*/
	public static readonly ReadmeMd_StringCreator_Type[] READMEMD_STRINGCREATOR = new ReadmeMd_StringCreator_Type[]{

		/** �T�v�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"# " + AUTHOR_NAME + "." + PACKAGE_NAME,
				"Excel����",
				"* �X�v���b�h�V�[�g����̓ǂݍ���",
				"* �o�C�i������̓ǂݍ���",
				"* JsonItem�ւ̃R���o�[�g",
			};
		},

		/** ���C�Z���X�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ���C�Z���X",
				"MIT License",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + "/blob/main/LICENSE",
			};
		},

		/** �ˑ��B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## �O���ˑ� / �g�p���C�Z���X��",
				"### �T���v���̂�",
				"* https://github.com/bluebackblue/AssetLib",
			};
		},

		/** ����m�F�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ����m�F",
				"Unity " + UnityEngine.Application.unityVersion,
			};
		},

		/** UPM�B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## UPM",
				"### �ŐV",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + ".git?path=unity_" + PACKAGE_NAME + "/Assets/UPM#" + a_argument.version,
				"### �J��",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + ".git?path=unity_" + PACKAGE_NAME + "/Assets/UPM",
			};
		},

		/** �C���X�g�[���B 
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## Unity�ւ̒ǉ����@",
				"* Unity�N��",
				"* ���j���[�I���F�uWindow->Package Manager�v",
				"* �{�^���I���F�u����́{�{�^���v",
				"* ���X�g�I���F�uAdd package from git URL...�v",
				"* ��LUPM��URL��ǉ��u https://github.com/�`�`/UPM#�o�[�W���� �v",
				"### ��",
				"Git�N���C�A���g���C���X�g�[������Ă���K�v������B",
				"* https://docs.unity3d.com/ja/current/Manual/upm-git.html",
				"* https://git-scm.com/",
			};
		},

		/** ��B
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ��",

				"* ```[root]```�̉E�̓V�[�g���B",
				"* ```[param_type]```�̉E�͌^���```string``` ```int``` ```float```���w��\�A```-```�n�܂�̓R�����g�����B",
				"* ```[param_name]```�̉E�͖��O��񋓁B",
				"* ```*```�̂���s���R���o�[�g�ΏہB",
				"* �I�[�ɂ�```[end]```���K�v�B",
				"* ���オ'''[end]''�̂���V�[�g�̓X�L�b�v����B",

				"![Sample01](/sample00.png)",

				"```",
				"{",
				"	\"sheetname\" : [",
				"		{",
				"			\"namae\" : \"satou\",",
				"			\"nedan\" : 10,",
				"			\"val\" : 1.3",
				"		},",
				"		{",
				"			\"namae\" : \"sio\",",
				"			\"nedan\" : 20,",
				"			\"val\" : 1.4",
				"		},",
				"		{",
				"			\"namae\" : \"shoyu\",",
				"			\"nedan\" : 30,",
				"			\"val\" : 1.5",
				"		}",
				"	]",
				"}",
				"```",

			};
		},
	};
}

