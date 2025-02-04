import {Dropdown, DropdownToggle, DropdownMenu, DropdownItem} from 'reactstrap'
import { useState } from 'react'
import { useAppContext } from '../../contexts/AppContext'
export const LeagueDropdownSwap = () => {
    const [dropdownOpen, setDropdownOpen] = useState(false)
    const toggle = () => setDropdownOpen((prevState) => !prevState)
    const  { userLeagues, setSelectedLeague, selectedLeague } = useAppContext()

    if (userLeagues) {
      return (
        <div className="d-flex p-5">
          <div>Viewed League: {selectedLeague.leagueName}</div>
          <Dropdown isOpen={dropdownOpen} toggle={toggle}>
            <DropdownToggle caret>Change League</DropdownToggle>
            <DropdownMenu>
              {userLeagues.map((l) => {
                return (
                  <DropdownItem 
                    key={l.leagueId}
                    onClick={() => setSelectedLeague(l)}
                  >
                    {l.leagueName}
                  </DropdownItem>
                )
              })}
              <DropdownItem header>Header</DropdownItem>
              <DropdownItem>Some Action</DropdownItem>
              <DropdownItem text>Dropdown Item Text</DropdownItem>
              <DropdownItem disabled>Action (disabled)</DropdownItem>
              <DropdownItem divider />
            </DropdownMenu>
          </Dropdown>
        </div>
      )
    } else {
      return <></>
    }

}