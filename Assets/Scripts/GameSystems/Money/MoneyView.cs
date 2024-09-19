using TMPro;
using UnityEngine;

namespace Money
{
    public sealed class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI moneyText;

        public void UpdateMoney(string text)
        {
            moneyText.text = text;
        }
    }
}