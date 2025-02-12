import { useState } from "react"
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"


export const RosterPositionDropdown = ({ rp }) => {
    const [dropDownOpen, setDropdownOpen] = useState()
    const toggle = () => setDropdownOpen((prevState) => !prevState)
    const { roster } = useAppContext()

    const HandlePositionChange = (taco) => {
        if (roster.rosterPlayers.some((rp) => rp.rosterPosition === taco)) {
            window.alert("Player already has that role")
        } else {
            // set the value - manager, endpoint
        }
    }


    // I think the simplest way to work this out would be an elseif based on rosterPosition and rp.player.position.positionShort
    // sadly the conditions are too ugly for a switch case... or are they? If I really wanted to validate rp in its entirety, I can just put the whole switch in an if that checks that.

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