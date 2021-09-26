using UnityEngine;
using UnityEngine.Playables;

public class TextClip : PlayableAsset
{
    [Multiline]
    public string text;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TextBehaviour>.Create(graph);

        var textBehaviour = playable.GetBehaviour();
        textBehaviour.text = text;

        return playable;
    }
}