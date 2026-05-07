# dnd-allies
A program for handling/tracking the homebrew Allies/Heroes in our dnd campaign

## Running dnd-allies
Go to the [Releases](https://github.com/sashastadler/dnd-allies/releases) page and follow the instructions for the most recent release.

## Adding custom allies
1. Make a copy of one of the existing allies in the `characters` folder. Note: the characters in the `playtest` folder may be out of date or missing information.
2. Rename the file to the name of the ally.
    This will be the name that shows up in the list of allies. Underscores are automatically replaced with spaces.
3. Open the .json file and change the values to be whatever needed for your character. It's important to maintain the overall json formatting, so do not add new fields or rename them.
4. (Optional) Add an image with the same name as the .json you made to the `/characters/images` folder.

### Alternatively
Here is a template. Copy and paste this into a new file. Edit values as needed. Name it whatever and make sure it is .json when you save it. If you're not very familiar with JSON files, feel free to reach out to me.

Optional fields that can be completely removed if not applicable to the ally:
- All of them

```
{
    "Name": "Ally Name",
    "Description": "Ally description.",
    "Hp": {
        "Max": 10
    },
    "Ac": 9999,
    "Speed": 9999,
    "Immunities": ["list", "any", "immunities", "here"],
    "Innate": {
        "Name": "Innate Name",
        "Description": "Innate description"
    },
    "Actions": [
        {
            "Name": "Action Name",
            "Description": "Action description. This action has sub options to pick from.",
            "Pool": {
                "Type": "Generic",
                "Max": 10,
                "Min": 0,
                "Current": 0
            },
            "SubOptions": [
                {
                    "Name": "Option 1",
                    "Description": "Description"
                },
                {
                    "Name": "Option 2",
                    "Description": "Description"
                }
            ]
        },
        {
            "Name": "Simple Action",
            "Description": "This action has no pool."
        }
    ],
    "Apex": {
        "Name": "APEX",
        "FlavorText": "This will be in italics"
        "Description": "Apex action description"
    }
}
```

## Future Improvements
Non-exhaustive list of updates I plan to make: (in not particular order) (⭐ = priority)
- Fix some of the spacing/sizing
- Add more allies
- Add more ally pictures
- CounterPool should not show input text box ideally
