using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor.Toolbar
{
	internal static class ToolbarStyles
	{
		public static readonly GUIStyle CommandButtonStyle;

		static ToolbarStyles()
		{
			CommandButtonStyle = new GUIStyle("Command")
			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageAbove,
				fontStyle = FontStyle.Bold
			};
		}
	}

	[InitializeOnLoad]
	public class SceneSwitchLeftButton
	{
		static SceneSwitchLeftButton()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

			if(GUILayout.Button(new GUIContent("GO!", "Base"), ToolbarStyles.CommandButtonStyle))
			{
				//SceneHelper.OpenLastLaunchScene();
				SceneHelper.StartScene("Base");
			}
			
			if(GUILayout.Button(new GUIContent("1", "Level 1"), ToolbarStyles.CommandButtonStyle))
			{
				//SceneHelper.OpenLastLaunchScene();
				SceneHelper.OpenScene("Level_1");
			}		
			
			if(GUILayout.Button(new GUIContent("2", "Level 1"), ToolbarStyles.CommandButtonStyle))
			{
				//SceneHelper.OpenLastLaunchScene();
				SceneHelper.OpenScene("Level_2");
			}
		}
	}
	

	static class SceneHelper
	{
		static string _sceneToOpen;

		public static void StartScene(string sceneName)
		{
			if(EditorApplication.isPlaying)
			{
				EditorApplication.isPlaying = false;
			}
			_sceneToOpen = sceneName;
			EditorApplication.update += OnUpdate;
		}
		public static void OpenScene(string sceneName)
		{
			string[] guids = AssetDatabase.FindAssets("t:scene " + sceneName, null);
			if (guids.Length == 0)
			{
				Debug.LogWarning("Couldn't find scene file");
			}
			else
			{
				string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
				EditorSceneManager.OpenScene(scenePath);
			}
		}
		

		static void OnUpdate()
		{
			if (_sceneToOpen == null ||
			    EditorApplication.isPlaying || EditorApplication.isPaused ||
			    EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
			{
				return;
			}

			EditorApplication.update -= OnUpdate;

			if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
			{
				// need to get scene via search because the path to the scene
				// file contains the package version so it'll change over time
				string[] guids = AssetDatabase.FindAssets("t:scene " + _sceneToOpen, null);
				if (guids.Length == 0)
				{
					Debug.LogWarning("Couldn't find scene file");
				}
				else
				{
					string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
					EditorSceneManager.OpenScene(scenePath);
					EditorApplication.isPlaying = true;
				}
			}
			_sceneToOpen = null;
		}


	}
}