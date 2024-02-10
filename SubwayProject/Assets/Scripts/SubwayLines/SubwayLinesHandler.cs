using BaseGraph.PathFinder;
using SubwayLines.Data;
using SubwayLines.Logic;
using UnityEngine;

namespace SubwayLines
{
    public class SubwayLinesHandler : MonoBehaviour
    {
        [SerializeField] private SubwayLinesView view;
        [SerializeField] private StationsData stationsData;
        [SerializeField] private SubwaySystemData subwaySystemData;

        private RouteSearchHandler searchHandler;

        private void Awake()
        {
            searchHandler = new RouteSearchHandler(subwaySystemData.subwaySystem, new BfsPathsFinder());
            view.Initialize(stationsData);
            view.OnButtonClicked += OnFindButtonClicked;
        }

        private void OnDestroy()
        {
            view.OnButtonClicked -= OnFindButtonClicked;
        }

        private void OnFindButtonClicked()
        {
            UpdateResults(view.FirstSelected, view.SecondSelected);
        }

        private void UpdateResults(int origin, int target)
        {
            var routes = searchHandler.GetSortedTravelRoutes(origin, target);
            var resultString = RouteUtils.ConvertRoutesToString(routes, stationsData);

            view.SetResultsText(resultString);
            Debug.Log(resultString);
        }
    }
}