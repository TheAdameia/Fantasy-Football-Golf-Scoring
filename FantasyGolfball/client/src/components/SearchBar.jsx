export const SearchBar = ({ setSearchTerm }) => {
    
    return (
        <div className="">
            <input type="text"
                onChange={(event) => {setSearchTerm(event.target.value)}}
                placeholder=""
            />
        </div>
    )
}