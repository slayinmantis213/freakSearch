    import React, { Component } from 'react';

    type ResultProps = {
        result: any
    }

    export class Result extends Component<ResultProps> {
        render() {
            const { result } = this.props;
            const { transcript, ...otherProps } = result;
    
            return (
                <div>
                    {Object.values(otherProps).join(', ')}
                </div>
            );
        }
    }
