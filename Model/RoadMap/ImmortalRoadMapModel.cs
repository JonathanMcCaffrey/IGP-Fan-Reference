using System.Collections.Generic;
using Model.RoadMap.Enums;

namespace Model.RoadMap;

public class ImmortalRoadMapModel
{
    public static readonly List<ImmortalRoadMapModel> Data = new()
    {
        new ImmortalRoadMapModel
        {
            Name = "UI Overhaul",
            Description =
                @"In the process of redoing the UI. Perhaps add 'Making Of' page for development related details, including a visual list of all components used, for ease of design reference. Ideally avoid menu bloat. Database, Build Calculator, Notes and Documentation, should be obvious main pages. Review 900px width on all pages.",
            Priority = ReleasePriorityType.High,
            Status = ReleaseStatusType.In_Development
        },
        new ImmortalRoadMapModel
        {
            Name = "Build Calculator Improvements",
            Description =
                @"The Calculator will be optimized to perform faster. It needs to be updated to consider training queue limits. Also, it needs error popups added for not enough ether, not enough supply, or no more interval time.",
            Priority = ReleasePriorityType.High,
            Status = ReleaseStatusType.Planned
        },
        new ImmortalRoadMapModel
        {
            Name = "Build Calculator Pyre",
            Description =
                @"Build calculator should also handle pyre generation over time. 2 key will represent taking pyre camps. Make sure people can mark ""casted"" pyre spells as a part of the build order.",
            Priority = ReleasePriorityType.Medium,
            Status = ReleaseStatusType.Planned
        },
        new ImmortalRoadMapModel
        {
            Name = "Build Comparisons",
            Description =
                @"You should be able to calculate two builds and load them against each other. Compare armies over time, to see when it would be best to strike against a certain build, and when it would be too late.",
            Priority = ReleasePriorityType.Medium,
            Status = ReleaseStatusType.Planned
        },
        new ImmortalRoadMapModel
        {
            Name = "Notes",
            Description =
                @"There should be general notes on how to play Immortal. Nothing too extensive, but general faction and gameplay feel, like mentioning mechanics like Overgrowth for Aru and Wards for Q'Rath. Interesting but basic lore notes are also ideal, but all of these notes still need to be sortable in a method that feels natural, not a giant text bloat.",
            Priority = ReleasePriorityType.High,
            Status = ReleaseStatusType.Planned
        },
        new ImmortalRoadMapModel
        {
            Name = "Documentation",
            Description =
                @"There should be documents on how to use this website. Calculator, Database, etc. Ideally, these documents will be designed in a way that becomes easily maintainable with patches. (Currently, some QA document type stuff is appended to the bottom of each tool page.) Add a button to easily go from the current tool, to its matching documented.",
            Priority = ReleasePriorityType.Medium,
            Status = ReleaseStatusType.Planned
        },
        new ImmortalRoadMapModel
        {
            Name = "Test Automation",
            Description =
                @"All patches should be tested via test automation, to avoid obvious bugs from getting into production. Add a informational test automation page to the Development section.",
            Priority = ReleasePriorityType.Medium,
            Status = ReleaseStatusType.Planned
        },
        new ImmortalRoadMapModel
        {
            Name = "Hot Key Reference",
            Description =
                @"Assuming the game continues to use Unreal-based hotkeys, there should be a reference for viewing and generating hotkey templates. Perhaps link to community hotkey files for people that do not wish to write their own.",
            Priority = ReleasePriorityType.Low,
            Status = ReleaseStatusType.Future_Possibility
        },
        new ImmortalRoadMapModel
        {
            Name = "Data Features",
            Description =
                @"Being able to save and load the state of the website would be cool. User's would keep all the data as JSON on their local machine, and just be able to load it when visiting the website. Being able to use the website offline would also be cool. People would only visit the live website to get updates. Perhaps offline website could do a check for this update version.",
            Priority = ReleasePriorityType.Very_Low,
            Status = ReleaseStatusType.Future_Possibility
        }
    };

    public string Name { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
}