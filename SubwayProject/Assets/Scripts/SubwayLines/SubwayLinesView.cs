using System;
using System.Collections.Generic;
using SubwayLines.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SubwayLines
{
    public class SubwayLinesView : MonoBehaviour
    {
        public event Action OnButtonClicked;
        public int FirstSelected => dropdownFirst.value;
        public int SecondSelected => dropdownSecond.value;

        [SerializeField] private TMP_Dropdown dropdownFirst;
        [SerializeField] private TMP_Dropdown dropdownSecond;
        [SerializeField] private TMP_Text resultsField;
        [SerializeField] private Button findButton;

        public void Initialize(StationsData data)
        {
            var optionsData = new List<TMP_Dropdown.OptionData>();
            foreach (var stationData in data.stations)
                optionsData.Add(new TMP_Dropdown.OptionData(stationData.Name));
            dropdownFirst.ClearOptions();
            dropdownSecond.ClearOptions();
            dropdownFirst.AddOptions(optionsData);
            dropdownSecond.AddOptions(optionsData);
            foreach (var stationData in data.stations)
            {
                dropdownFirst.options[stationData.ID].text = stationData.Name;
                dropdownSecond.options[stationData.ID].text = stationData.Name;
            }

            dropdownSecond.value = 1;
        }

        public void SetResultsText(string text)
        {
            resultsField.text = text;
        }

        private void Start()
        {
            findButton.onClick.AddListener(() => OnButtonClicked?.Invoke());
        }

        private void OnDestroy()
        {
            findButton.onClick.RemoveListener(() => OnButtonClicked?.Invoke());
        }
    }
}