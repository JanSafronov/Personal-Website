

class TopPanel extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                <div className="container">
                    <a className="navbar-brand" href="./Index.html">Open Source Developer</a>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                        <ul className="navbar-nav flex-grow-1">
                            <li className="nav-item">
                                <a className="nav-link text-dark" href="./Index.html">Home</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link text-dark" href="./Privacy.html">Privacy</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link text-dark" href="./Contact.html">Contact</a>
                            </li>
                        </ul>
                        <p className="nav navbar-text">Hello, Anonymous!</p>
                    </div>
                </div>
            </nav>
        );
    }
}

const BottomPanel = (props) => {
    return (
        <div className="container">
            &copy; 2021 - JanWBsite - <a href="./Privacy.html">Privacy</a>
        </div>
    );
}

ReactDOM.render(<TopPanel/>, document.getElementById("top-container"));
ReactDOM.render(<BottomPanel/>, document.getElementById("bottom-container"));