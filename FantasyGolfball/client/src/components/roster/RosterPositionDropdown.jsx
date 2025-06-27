import { useState } from "react"
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { ChangeRosterPlayerPosition } from "../../managers/rosterPlayerManager"


export const RosterPositionDropdown = ({ rp, rosterLock }) => {
    const [dropDownOpen, setDropdownOpen] = useState()
    const toggle = () => setDropdownOpen((prevState) => !prevState)
    const { roster, getAndSetRoster, selectedLeague } = useAppContext()
    const rosterOptions = ["bench", "QB1", "WR1", "WR2", "RB1", "RB2", "FLEX", "TE1", "K", "DEF"]

    const HandlePositionChange = async (newPosition) => {  // needs to be async to make sure db updates before refresh
        if (rosterLock == true) {
            window.alert("Can't do that while Roster is locked!")
            return
        }
        if (roster.rosterPlayers.some((rosterPlayer) => rosterPlayer.rosterPosition === newPosition) && newPosition != "bench") {
            window.alert("Player already has that role")
        } else {
            await ChangeRosterPlayerPosition(rp.rosterPlayerId, newPosition, selectedLeague.leagueId)
            await getAndSetRoster()
        }
    }

    if (rp) {
        switch(rp.player.position.positionShort) {
            case "QB":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[0])}>
                                Bench
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[1])}>
                                QB1
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "WR":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[0])}>
                                Bench
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[2])}>
                                WR1
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[3])}>
                                WR2
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[6])}>
                                FLEX
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "RB":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[0])}>
                                Bench
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[4])}>
                                RB1
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[5])}>
                                RB2
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[6])}>
                                FLEX
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "TE":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[0])}>
                                Bench
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[7])}>
                                TE1
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[6])}>
                                FLEX
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "K":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[0])}>
                                Bench
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[8])}>
                                K
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "DEF":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[0])}>
                                Bench
                            </DropdownItem>
                            <DropdownItem onClick={() => HandlePositionChange(rosterOptions[9])}>
                                DEF
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            default:
                return (
                    <div>loading...</div>
                )
        }
    }
}