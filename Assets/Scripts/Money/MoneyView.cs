using DefaultNamespace;
using TMPro;
using UnityEngine;
using Zenject;

namespace Money
{
    public sealed class MoneyView:MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI moneyText;

        [SerializeField]
        private TeamData team;
        
        private MoneyPresenter _moneyPresenter;

        [Inject]
        public void Construct(MoneyPresenter moneyPresenter)
        {
            _moneyPresenter = moneyPresenter;
            _moneyPresenter.OnMoneyChanged += UpdateMoney;
        }

        private void UpdateMoney(string text, TeamData teamData)
        {
            if (team == teamData)
                moneyText.text = text;
        }

        public void OnDestroy()
        {
            _moneyPresenter.OnMoneyChanged -= UpdateMoney;
        }
    }
}