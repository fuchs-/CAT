path:
fighters/[universe]/[fighter-id]

contents:
---mandatory---
fighter.json - all fighter data, id, name, stats, info on abilities
abilities.cat - ability and effects behavior written on CAT script (check CATScript_doc.txt)
sprites folder 
    char.png
    unit.png 
    all sprites used by the fighter's abilities

---optional---
units folder
    [unit-id] folder
        abilities.cat - ability and effects behavior written on CAT script (check CATScript_doc.txt)
        sprites folder 
            char.png
            unit.png 
            all sprites used by the unit's abilities
    
