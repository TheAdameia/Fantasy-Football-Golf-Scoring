import { FormatStats } from "../widgets/FormatStats"

export const SavedMatchupPlayerCard = ({ musp, slot, week }) => {

    if (slot) {
        return (
            <tr className="player-table-row">
                <td className="stats-no-fade">
                    {FormatStats(musp.scoring)}
                </td>
                <td className="player-table-font">
                    {musp.rosterPlayerPosition}
                </td>
                <td className="player-table-font">
                    {musp.player.playerFullName}
                </td>
                <td className="player-table-font">
                    {musp.player.playerTeams[0].team.teamName}
                </td>
                <td className="player-table-font">
                    {musp.player.playerStatuses[0].status.statusType}
                </td>
                <td>
                    {musp.scoring.points.toFixed(2)}
                </td>
            </tr>
        )
       } else if (slot == false) {
        return (
            <tr className="player-table-row">
                <td>
                    {musp.scoring.points.toFixed(2)}
                </td>
                <td className="player-table-font">
                    {musp.player.playerStatuses[0].status.statusType}
                </td>
                <td className="player-table-font">
                    {musp.player.playerTeams[0].team.teamName}
                </td>
                <td className="player-table-font">
                    {musp.player.playerFullName}
                </td>
                <td className="player-table-font">
                    {musp.rosterPlayerPosition}
                </td>
                <td className="stats-no-fade">
                    {FormatStats(musp.scoring)}
                </td>
            </tr>
        )
       } else {
        <div>
            loading...
        </div>
       }
}