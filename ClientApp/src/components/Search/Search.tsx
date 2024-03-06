import React, {FC} from 'react';
import { SearchBar } from './SearchBar.tsx';
import { SearchButton } from './SearchButton.tsx';
import FormGroup from '@mui/material/FormGroup';
import '../../custom.css';

export const Search: FC<{ searchButtonClicked: () => void }> = ({ searchButtonClicked }) => {

    return (
        <div className='search'>
            <h1>Search for Episodes</h1>
            <FormGroup row={true}>
                <form>
                <SearchBar />
                <SearchButton handleButtonClick={searchButtonClicked} />
                </form>
            </FormGroup>
        </div>
    );
};

