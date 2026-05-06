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
- HP
- Pool (if an Action doesn't have a pool (most don't))
- SavingThrow
- Actions (if no actions).
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
            "Description": "Action description.",
            "Pool": {
                "Type": "Generic",
                "Max": 10,
                "Min": 0,
                "Current": 0
            }
        },
        {
            "Name": "Simple Action",
            "Description": "This action has no pool or saving throw."
        }
    ],
    "Apex": null
}
```

## Future Improvements
Non-exhaustive list of updates I plan to make: (in not particular order) (⭐ = priority)
- AC optional (for allies with no AC) - currently AC will always display
- Speed optional (same as above)
- Immunities should show "none" if no immunities are specified
- Add Apex actions ⭐
- Fix some of the spacing/sizing
- Add more allies
- Add more ally pictures
- Innate abilities with a Pool that counts up/down (for those characters that store the damage they take/deal, for example)
