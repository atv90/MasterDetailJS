class näytäTunnit extends React.Component {
    render() {
        return (
            <p>Projekti: {this.props.projektinnimi}</p>
                );
    }
}

render(){
   
    return (
        <näytäTunnit projektinnimi={this.state.projektinnimi}></näytäTunnit>
    );
}

class Table extends React.Component {
    render() {
        return (
            <BootstrapTable data={products}>
                <TableHeaderColumn dataField='id' isKey>Product ID</TableHeaderColumn>
                <TableHeaderColumn dataField='name'>Product Name</TableHeaderColumn>
                <TableHeaderColumn dataField='price'>Product Price</TableHeaderColumn>
            </BootstrapTable>
        );
    }
}