//#define DOTween
#if DOTween
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.Tilemaps;

namespace HuntroxGames.Utils
{
    public static class DoTweenExtension
    {
        #region Text

        public static TweenerCore<string, string, StringOptions> DOText(this TextMeshProUGUI textmesh, string endValue,
            float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None,
            string scrambleChars = null)
        {
            if (endValue == null)
            {
                endValue = "";
            }

            textmesh.text = "";
            TweenerCore<string, string, StringOptions> tween = DOTween.To(() => textmesh.text, x => textmesh.text = x,
                endValue, duration);
            tween.SetOptions(richTextEnabled, scrambleMode, scrambleChars)
                .SetTarget(textmesh);
            return tween;
        }

        public static TweenerCore<string, string, StringOptions> DOText(this TextMeshPro textmesh, string endValue,
            float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None,
            string scrambleChars = null)
        {
            if (endValue == null)
            {
                endValue = "";
            }

            textmesh.text = "";
            TweenerCore<string, string, StringOptions> tween = DOTween.To(() => textmesh.text, x => textmesh.text = x,
                endValue, duration);
            tween.SetOptions(richTextEnabled, scrambleMode, scrambleChars)
                .SetTarget(textmesh);
            return tween;
        }

        #endregion

        #region Image

        public static TweenerCore<float, float, FloatOptions> DOFill(this Image target, float endValue, float duration)
        {
            if (endValue < 0)
                endValue = 0;
            TweenerCore<float, float, FloatOptions> tween = DOTween.To(() => target.fillAmount,
                x => target.fillAmount = x, endValue, duration);
            return tween;
        }

        #endregion

        #region Tilemap

        public static TweenerCore<Color, Color, ColorOptions> DOFade(this Tilemap target, float endValue,
            float duration)
        {
            if (endValue < 0)
                endValue = 0;
            TweenerCore<Color, Color, ColorOptions> tween = DOTween.To(() => target.color, x => target.color = x,
                new Color(target.color.r, target.color.g, target.color.b, endValue), duration);
            return tween;
        }

        public static TweenerCore<Color, Color, ColorOptions> DOColor(this Tilemap target, Color endValue,
            float duration)
        {
            TweenerCore<Color, Color, ColorOptions> tween = DOTween.To(() => target.color, x => target.color = x,
                endValue, duration);
            return tween;
        }

        #endregion

        #region SpriteRenderer

        public static TweenerCore<Vector2, Vector2, VectorOptions> DOSize(this SpriteRenderer target, Vector2 endValue,
            float duration)
        {
            TweenerCore<Vector2, Vector2, VectorOptions> tween = DOTween.To(() => target.size, x => target.size = x,
                endValue, duration);
            return tween;
        }
        
        #endregion
        public static TweenerCore<float, float, FloatOptions> DOWeight(this Volume target, float endValue,
            float duration)
        {
            if (endValue < 0)
                endValue = 0;
            TweenerCore<float, float, FloatOptions> tween = DOTween.To(() => target.weight, x => target.weight = x,
                endValue, duration);
            return tween;
        }
    }
}
#endif