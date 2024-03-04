import React, {FC} from 'react';
import { SearchBar } from './SearchBar.tsx';
import { SearchButton } from './SearchButton.tsx';

export const Search: FC = ({searchButtonClicked}) => {

    return (
        <div>
            <h1>Search for Episodes</h1>
            <SearchBar />
            <SearchButton handleButtonClick={searchButtonClicked}/>
        </div>
    );
};

