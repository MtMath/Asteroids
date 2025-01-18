using UnityEditor;

namespace Editor
{
    internal static class TagsDefine
    {
        [InitializeOnLoadMethod]
        public static void AddTags()
        {
            var tags = new[]
            {
                "Asteroid",
                "Projectile",
            };

            foreach (var tag in tags) AddTag(tag);
        }

        private static void AddTag(string tag)
        {
            var asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            
            if (asset is { Length: > 0 })
            {
                var so = new SerializedObject(asset[0]);
                var tags = so.FindProperty("tags");

                for (var i = 0; i < tags.arraySize; ++i)
                {
                    if (tags.GetArrayElementAtIndex(i).stringValue == tag)
                    {
                        return;
                    }
                }
            
                tags.InsertArrayElementAtIndex(0);
                tags.GetArrayElementAtIndex(0).stringValue = tag;
                so.ApplyModifiedProperties();
                so.Update();
            }
        }
    }
}