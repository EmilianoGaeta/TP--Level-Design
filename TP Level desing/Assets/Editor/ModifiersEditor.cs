using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Modifiers))]
public class ManEditor : Editor
{
    private Modifiers values;

    private void OnEnable()
    {
        values = (Modifiers)target;
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space();
        values.floorchance = EditorGUILayout.Slider("Gap Chance: ", values.floorchance, 5, 90);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Min 3, Max 10");
        values.maxfloorgapsize = EditorGUILayout.IntField( "Max Floor Gap Size", values.maxfloorgapsize);
        if (values.maxfloorgapsize < 3) { values.maxfloorgapsize = 3; }
        if (values.maxfloorgapsize > 10) { values.maxfloorgapsize = 10; }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        values.spikechance = EditorGUILayout.Slider("Spike Chance: ", values.spikechance, 5, 80);
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        values.platformBlockchance = EditorGUILayout.Slider("Random Platform Chance: ", values.platformBlockchance, 5, 80);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Min 1, Max 5");
        values.platfomrsize = EditorGUILayout.IntField("Platform Max Size", values.platfomrsize);
        if (values.platfomrsize < 1) { values.platfomrsize = 1; }
        if (values.platfomrsize > 5) { values.platfomrsize = 5; }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Min 3, Max 8");
        values.initialspace = EditorGUILayout.IntField("Initial Space", values.initialspace);
        if (values.initialspace < 3) { values.initialspace = 3; }
        if (values.initialspace > 8) { values.initialspace = 8; }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Min 2, Max 8");
        values.finalspace = EditorGUILayout.IntField("Final Space", values.finalspace);
        if (values.finalspace < 2) { values.finalspace = 2; }
        if (values.finalspace > 8) { values.finalspace = 8; }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Min 1, Max 8");
        values.platformSpacezice = EditorGUILayout.IntField("Space Between Platforms", values.platformSpacezice);
        if (values.platformSpacezice < 1) { values.platformSpacezice = 1; }
        if (values.platformSpacezice > 8) { values.platformSpacezice = 8; }
        EditorGUILayout.Space();
        values.cameraspeed = EditorGUILayout.Slider("Camera Speed", values.cameraspeed, 1, 5);
        EditorGUILayout.Space();
        values.initialtime = EditorGUILayout.Slider("Initial Time", values.initialtime, 2, 5);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Min 30, Max 100");
        values.levellenght = EditorGUILayout.IntField("Level Size", values.levellenght);
        if (values.levellenght < 30) { values.levellenght = 30; }
        if (values.levellenght > 100) { values.levellenght = 100; }
    }
}