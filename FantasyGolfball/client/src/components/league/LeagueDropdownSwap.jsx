import {Dropdown, DropdownToggle, DropdownMenu, DropdownItem} from 'reactstrap'
import { useState } from 'react'
import { useAppContext } from '../../contexts/AppContext'
export const LeagueDropdownSwap = () => {
    const [dropdownOpen, setDropdownOpen] = useState(false)
    const toggle = () => setDropdownOpen((prevState) => !prevState)
    const  { userLeagues, setSelectedLeague, selectedLeague } = useAppContext()

    if (userLeagues && userLeagues.length > 0) {
      return (
        <div>
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
            </DropdownMenu>
          </Dropdown>
        </div>
      )
    } else {
      return null
    }

}