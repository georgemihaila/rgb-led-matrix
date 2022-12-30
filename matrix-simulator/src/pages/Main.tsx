import VirtualMatrixConfigurator from "../components/VirtualMatrixConfigurator";
import Draggable from "react-draggable";

function Main() {
    return <>
        <Draggable>
            <div>
                <VirtualMatrixConfigurator />
            </div>
        </Draggable>
    </>
};

export default Main;