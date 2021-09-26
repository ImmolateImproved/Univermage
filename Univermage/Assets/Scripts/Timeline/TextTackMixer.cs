using TMPro;
using UnityEngine.Playables;

public class TextTackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var textMesh = playerData as TextMeshProUGUI;

        var currentText = "";
        var currentAlpha = 0f;

        if (!textMesh) return;

        var inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            var inputWeight = playable.GetInputWeight(i);

            if (inputWeight > 0)
            {
                var inputPlayable = (ScriptPlayable<TextBehaviour>)playable.GetInput(i);

                var input = inputPlayable.GetBehaviour();
                currentText = input.text;
                currentAlpha = inputWeight;
            }
        }

        textMesh.text = currentText;

        var color = textMesh.color;
        color.a = currentAlpha;
        textMesh.color = color;
    }
}