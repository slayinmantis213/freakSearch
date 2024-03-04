import React, {FC} from 'react';

export const SearchButton: FC = ({handleButtonClick}) => {

    return (
        <div>
            <button onClick={handleButtonClick}>Search</button>
        </div>
    );
};