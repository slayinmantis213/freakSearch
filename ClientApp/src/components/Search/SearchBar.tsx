import React, {FC} from 'react';
import Input from '@mui/material/Input';


export const SearchBar: FC = () => {


    return (
        <div>
            <Input fullWidth={true} autoFocus={true} type="text" name="" id="searchInput" />
        </div>
    );
}