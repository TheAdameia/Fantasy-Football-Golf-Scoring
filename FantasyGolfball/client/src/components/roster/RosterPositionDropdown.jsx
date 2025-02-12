import { useState } from "react"
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"
import { ChangeRosterPlayerPosition } from "../../managers/rosterPlayerManager"


export const RosterPositionDropdown = ({ rp }) => {
    const [dropDownOpen, setDropdownOpen] = useState()
    const toggle = () => setDropdownOpen((prevState) => !prevState)
    const { roster } = useAppContext()

    const HandlePositionChange = (taco) => { // taco needs to be event.value I think, onSelect or whatever
  
        if (roster.rosterPlayers.some((rp) => rp.rosterPosition === taco) && taco != "bench") {
            window.alert("Player already has that role")
        } else if (taco == "bench") {
            ChangeRosterPlayerPosition(rp.rosterPlayedId, taco)
        } else if (taco != "bench") {
            ChangeRosterPlayerPosition(rp.rosterPlayedId, taco)
        } else {
            window.alert("input error")
        }
    }

    if (rp) {
        switch(rp.player.position.positionShort) {
            case "QB":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem>
                                Bench
                            </DropdownItem>
                            <DropdownItem>
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
                            <DropdownItem>
                                Bench
                            </DropdownItem>
                            <DropdownItem>
                                WR1
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "RB":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem>
                                Bench
                            </DropdownItem>
                            <DropdownItem>
                                RB1
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "TE":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem>
                                Bench
                            </DropdownItem>
                            <DropdownItem>
                                TE1
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                )
            case "K":
                return (
                    <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                        <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem>
                                Bench
                            </DropdownItem>
                            <DropdownItem>
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
                            <DropdownItem>
                                Bench
                            </DropdownItem>
                            <DropdownItem>
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