import React, {FC} from 'react';
import Button from '@mui/material/Button';

interface SearchButtonProps {
    handleButtonClick: () => void;
}

export const SearchButton: FC<SearchButtonProps> = ({handleButtonClick}) => {

    return (
        <div>
            <Button variant="outlined" onClick={handleButtonClick} onSubmit={handleButtonClick}>Search</Button>
        </div>
    );
};