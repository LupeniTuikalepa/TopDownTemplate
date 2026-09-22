#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Lightbug.CharacterControllerPro.Core
{
    public class WelcomeWindow : CharacterControllerProWindow
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            this.position = new Rect(10f, 10f, 700f, 700f);
            this.maxSize = this.minSize = this.position.size;
        }

        [MenuItem("Window/Character Controller Pro/Upgrade guide 1.5.x", false, 0)]
        public static void OpenUpgradeGuide()
        {
            string[] results = AssetDatabase.FindAssets("Upgrade guide 1.5.x");
            if (results.Length == 0)
                return;

            OpenProjectFile(results[0]);
        }

        static void OpenProjectFile(string guid)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var projectPathWithoutAssets = Application.dataPath.Substring(0, Application.dataPath.Length - 6);
            Application.OpenURL(projectPathWithoutAssets + path);
        }

        void OnGUI()
        {

            GUILayout.Label("Character Controller Pro", titleStyle);

            GUILayout.Space(20f);

            GUILayout.BeginVertical("Box");
            if (GUILayout.Button("Test"))
                Debug.Log(CharacterControllerProEditor.GetAssetRootFolder());

            GUILayout.Label("<b>Upgrade to 1.5.X</b>", subtitleStyle);

            GUILayout.Label("Are you upgrading to 1.5.x?\nPlease read the <b>upgrade guide</b> " +
                            "(<i>Character Controller Pro/Documentation/Upgrade guide 1.5.0.pdf</i>)", descriptionStyle);
            if (GUILayout.Button("Upgrade guide"))
                OpenUpgradeGuide();
            GUILayout.EndVertical();

            GUILayout.Space(10f);

            GUILayout.BeginVertical("Box");
            GUILayout.Label("<b>Demo setup</b>", subtitleStyle);

            GUILayout.Label(
            "The demo scenes and demo characters all <b>require the (new) input system installed</b> in your project. Otherwise, inputs " +
            "won't have any effect at all.", descriptionStyle);

            GUILayout.Label(
                "Go to the package manager, download and import the 'Input System' package.", descriptionStyle);
            
            GUILayout.Space(10f);

            GUILayout.EndVertical();

            GUILayout.Space(10f);

            GUILayout.BeginVertical("Box");
            GUILayout.Label("<b>Known issues (editor)</b>", subtitleStyle);
            GUILayout.Label("Please check the \"Known issues\" section if you are experiencing " +
            "problems while testing the demo content. These are (most of the time) issues related to the Unity editor itself.", descriptionStyle);
            if (GUILayout.Button("Known issues", EditorStyles.miniButton))
            {
                Application.OpenURL("https://lightbug14.gitbook.io/ccp/package/known-issues");
            }

            GUILayout.EndVertical();

            GUILayout.Space(10f);

            GUILayout.Space(10f);
            GUILayout.Label("You can open this window from the top menu: \n<i>Window/Character Controller Pro/Welcome</i>", descriptionStyle);

        }

    }

}

#endif
