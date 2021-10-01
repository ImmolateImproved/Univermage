﻿using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(SaveSystem))]
public class SaveableHolderEditor : Editor
{
    private SaveSystem saveableHolder;
    private VisualElement root;

    private VisualTreeAsset visualTree;

    private void OnEnable()
    {
        saveableHolder = target as SaveSystem;

        root = new VisualElement();
        visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets\\Scripts\\UI\\Editor\\SaveManager.uxml");
        //var uss = AssetDatabase.LoadAssetAtPath<StyleSheet>("Asset/UI/SaveManager.uss");
        //root.styleSheets.Add(uss);

    }

    public override VisualElement CreateInspectorGUI()
    {
        var root = this.root;
        root.Clear();

        var iterator = serializedObject.GetIterator();
        if (iterator.NextVisible(true))
        {
            do
            {
                var propertyField = new PropertyField(iterator.Copy()) { name = "PropertyField:" + iterator.propertyPath };

                if (iterator.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    propertyField.SetEnabled(value: false);

                root.Add(propertyField);
            }
            while (iterator.NextVisible(false));
        }

        visualTree.CloneTree(root);

        var findSaveablesButton = root.Q<Button>("FindSaveables");
        findSaveablesButton.clicked += SaveManagerEditor_clicked;

        return root;
    }

    private void SaveManagerEditor_clicked()
    {
        saveableHolder.FindSaveables();
        EditorUtility.SetDirty(saveableHolder);
    }
}