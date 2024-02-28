// import React, {Component} from 'react';

// export class EpisodesSearch extends Component {
//     render(){
//         return (
//         <div>
//             EpisodesSearch
//         </div>
//     )}
// }

import React, { Component } from 'react';

export class EpisodesSearch extends Component {
    state = {
        episodes: null,
    };

    componentDidMount() {
        fetch('https://localhost:7099/api/Episode/AllEpisodes')
            .then((response) => response.json())
            .then((data) => {
                this.setState({ episodes: data });
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }

    render() {
        const { episodes } = this.state;

        return (
            <div>
                {episodes ? (
                    <pre>{JSON.stringify(episodes, null, 2)}</pre>
                ) : (
                    <div>Loading episodes...</div>
                )}
            </div>
        );
    }
}