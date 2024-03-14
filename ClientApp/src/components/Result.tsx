    import React, { Component } from 'react';
    import Paper from '@mui/material/Paper';
    import Link from '@mui/material/Link';


    type ResultProps = {
        result: any
    }

    export class Result extends Component<ResultProps> {
        render() {
            const { result } = this.props;
            const { transcript, ...otherProps } = result;
    
            return (
                <Paper elevation={3} sx={{width:1000, padding:2}}>
                    <h3><Link href={otherProps.link} target="_blank" rel="noreferrer">{otherProps.episodeNumber}</Link></h3>
                    <h4>{otherProps.title}</h4>
                    <Paper elevation={0} sx={{padding:2}}>Summary: {otherProps.summary}</Paper>
                </Paper>
            );
        }
    }
