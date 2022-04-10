using Model.Website.Enums;

namespace Services.Website;

public class NavigationService : INavigationService {
    private string navigationStateType = NavigationStateType.Default;

    private NavSelectionType navSelectionType = NavSelectionType.None;

    private Type renderType = null!;
    private int webPageType;
    private int webSectionType;

    public void Subscribe(Action action) {
        OnChange += action;
    }

    public void Unsubscribe(Action action) {
        OnChange += action;
    }

    public void ChangeNavigationState(string newState) {
        if (newState.Equals(navigationStateType))
            return;

        navigationStateType = newState;

        NotifyDataChanged();
    }

    public string GetNavigationState() {
        return navigationStateType;
    }

    public void SelectPage(int pageType, Type page) {
        if (renderType != page) {
            renderType = page;
            webPageType = pageType;
            navSelectionType = NavSelectionType.Page;
            NotifyDataChanged();
        }
    }


    public void SelectSection(int section) {
        if (section == webSectionType) return;
        webSectionType = section;
        navSelectionType = NavSelectionType.Section;

        Console.WriteLine(webSectionType);
        NotifyDataChanged();
    }

    public void Back() {
        if (navSelectionType == NavSelectionType.Page) {
            navSelectionType = NavSelectionType.Section;
            webPageType = 0;
            NotifyDataChanged();
            return;
        }

        if (navSelectionType == NavSelectionType.Section) {
            navSelectionType = NavSelectionType.None;
            webSectionType = 0;
            webPageType = 0;
            NotifyDataChanged();
        }
    }

    public NavSelectionType GetNavSelectionType() {
        return navSelectionType;
    }

    public int GetWebPageId() {
        return webPageType;
    }

    public int GetWebSectionId() {
        return webSectionType;
    }

    public Type GetRenderType() {
        return renderType;
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged() {
        OnChange?.Invoke();
    }
}