import { useState } from "react"
import { Dropdown, DropdownItem, DropdownMenu, DropdownToggle } from "reactstrap"
import { useAppContext } from "../../contexts/AppContext"


export const RosterPositionDropdown = ({ rp }) => {
    const [dropDownOpen, setDropdownOpen] = useState()
    const toggle = () => setDropdownOpen((prevState) => !prevState)
    const { roster } = useAppContext()

    const HandlePositionChange = () => {
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
                                QB1
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
                                QB1
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
                                QB1
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
                                QB1
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


    // if ( rp && rp.player.position.positionShort === "QB") {

    // } else if (rp && rp.player.position.positionShort === "WR") {

    // } else if (rp && rp.player.position.positionShort === "RB") {

    // } else if (rp && rp.player.position.positionShort === "TE") {

    // } else if (rp && rp.player.position.positionShort === "K") {

    // } else if (rp && rp.player.position.positionShort === "DEF") {

    // }

    if (rp) {
        return (
            <Dropdown isOpen={dropDownOpen} toggle={toggle}>
                <DropdownToggle caret>{rp.rosterPosition}</DropdownToggle>
                <DropdownMenu>
                    <DropdownItem>

                    </DropdownItem>
                </DropdownMenu>
            </Dropdown>
        )
    }
}