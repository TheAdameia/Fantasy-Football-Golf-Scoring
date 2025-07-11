

// I need to do a lot here. But more than that, I probably need to figure out
// how the hell scoring is going to work. There's gonna be so much that goes
// into that class. It'll probably have 30 properties by the time I'm done,
// and there will be a lot of math to calculate the score.

// Let's start by listing what Scoring has, and what it doesn't have, but it
// will need:

// ScoringId, PlayerId, SeasonId, SeasonWeek, Points.
// No point to change any of those except Points, which will end up being a calculated property.

// What else could it use?
// Opposing team as a navigational property. For the sake of displaying the
// actual game that was played. Maybe a new class with more info on the date
// and time. Something to think about.

// Every scoring category, obviously. They'd have to all be nullable.

// Elegantly deal with the "points against" problem: have a bool IsDefense
// that determines whether it is calculated in points or not.

// I guess that's it? Once I think about it, and with IsDefense, I really don't
// think there should be any problem just making all the stats nullable.
// You just control which stats are displayed based on the position. Or, actually,
// you really only have to do that with K and DEF.