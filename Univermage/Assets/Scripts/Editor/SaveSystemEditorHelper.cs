using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

namespace UnityToolbarExtender.Examples
{
    static class ToolbarStyles
    {
        public static readonly GUIStyle commandButtonStyle;

        static ToolbarStyles()
        {
            commandButtonStyle = new GUIStyle("Command")
            {
                fontSize = 16,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold
            };
        }
    }

    [InitializeOnLoad]
    public class SaveSystemInitializeButton
    {
        static SaveSystemInitializeButton()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            if (GUILayout.Button(new GUIContent("All", "Initialize save system for all scenes"), ToolbarStyles.commandButtonStyle))
            {
                SaveSystemEditorHelper.InitializeAllScenes();
            }
            if (GUILayout.Button(new GUIContent("S1", "Initialize save system for current scene"), ToolbarStyles.commandButtonStyle))
            {
                SaveSystemEditorHelper.InitializeCurrentScene();
            }
        }
    }

    static class SaveSystemEditorHelper
    {
        public static void InitializeAllScenes()
        {
            EditorSceneManager.sceneOpened += OnSceneOpened;

            var allScenes = EditorBuildSettings.scenes;

            var currentScene = EditorSceneManager.GetActiveScene().buildIndex;

            for (int i = 2; i < allScenes.Length; i++)
            {
                var scenePath = allScenes[i].path;

                EditorSceneManager.OpenScene(scenePath);
            }

            EditorSceneManager.sceneOpened -= OnSceneOpened;

            EditorSceneManager.OpenScene(allScenes[currentScene].path);
        }

        public static void InitializeCurrentScene()
        {
            var saveSystem = GameObject.FindObjectOfType<GameplaySaveSystem>();

            if (!saveSystem)
            {
                return;
            }

            saveSystem.FindSaveables();

            EditorUtility.SetDirty(saveSystem);
            EditorSceneManager.SaveOpenScenes();
        }

        private static void OnSceneOpened(UnityEngine.SceneManagement.Scene scene, OpenSceneMode mode)
        {
            if (scene.buildIndex < 2)
                return;

            InitializeCurrentScene();
        }
    }
}