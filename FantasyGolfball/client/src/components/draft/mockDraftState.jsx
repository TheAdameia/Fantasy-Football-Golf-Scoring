

export const mockDraftState = {
    leagueId: 1,
    currentUserId: 1, // Simulated user ID for the current turn
    nextAutoDraftPlayer: {
        playerId: 21,
        playerFirstName: "Ryan",
        playerLastName: "Fitzgerald",
        positionId: 4,
        statusId: 1,
        position: {
          positionId: 4,
          positionShort: "TE",
          positionLong: "Tight End"
        },
        status: {
          statusId: 1,
          statusType: "Green",
          viableToPlay: true,
          requiresBackup: false
        }
      },
    availablePlayers: [
        {
            playerId: 1,
            playerFirstName: "Jake",
            playerLastName: "Mason",
            positionId: 1,
            statusId: 1,
            position: {
              positionId: 1,
              positionShort: "QB",
              positionLong: "Quarterback"
            },
            status: {
              statusId: 1,
              statusType: "Green",
              viableToPlay: true,
              requiresBackup: false
            }
        },
        {
            playerId: 21,
            playerFirstName: "Ryan",
            playerLastName: "Fitzgerald",
            positionId: 4,
            statusId: 1,
            position: {
              positionId: 4,
              positionShort: "TE",
              positionLong: "Tight End"
            },
            status: {
              statusId: 1,
              statusType: "Green",
              viableToPlay: true,
              requiresBackup: false
            }
        },
        {
            playerId: 61,
            playerFirstName: "Aiden",
            playerLastName: "Miller",
            positionId: 2,
            statusId: 1,
            position: {
              positionId: 2,
              positionShort: "WR",
              positionLong: "Wide Receiver"
            },
            status: {
              statusId: 1,
              statusType: "Green",
              viableToPlay: true,
              requiresBackup: false
            }
        },
        {
            playerId: 101,
            playerFirstName: "Owen",
            playerLastName: "Taylor",
            positionId: 3,
            statusId: 1,
            position: {
              positionId: 3,
              positionShort: "RB",
              positionLong: "Running Back"
            },
            status: {
              statusId: 1,
              statusType: "Green",
              viableToPlay: true,
              requiresBackup: false
            }
        },
    ],
    userTurnOrder: [
        { userId: 1, name: "User A" },
        { userId: 2, name: "User B" },
        { userId: 3, name: "User C" },
        { userId: 4, name: "User D" },
    ],
};
