using BridgePattern.Classes;

Cosmetics cream = new Cream(new MoisturizingCare());
cream.DoChanges();
Cosmetics cream2 = new Cream(new CalmingCare());
cream2.DoChanges();

Cosmetics gel = new Gel(new CalmingCare());
gel.DoChanges();
Cosmetics gel2 = new Gel(new MoisturizingCare());
gel2.DoChanges();