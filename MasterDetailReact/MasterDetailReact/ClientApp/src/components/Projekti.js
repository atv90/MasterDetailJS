import React, { Component } from 'react';

export class ProjektiData extends Component {
    displayName = ProjektiData.name

    constructor(props) {
        super(props);
        this.state = { projektit: [], loading: true };

        fetch('api/Projekti/Index')
            .then(response => response.json())
            .then(data => {
                this.setState({ projektit: data, loading: false });
            });
    }

    static renderProjektiTable(projektit) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Nimi</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    {projektit.map(projekti =>
                        <tr key={projekti.ProjektiId}>
                            <td>{projekti.Nimi}</td>
                            <td>{projekti.Status}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Lataa...</em></p>
            : ProjektiData.renderProjektiTable(this.state.projektit);

        return (
            <div>
                <h1>Projektit</h1>
                <p>uuuu</p>
                {contents}
            </div>
        );
    }
}
